import React, { useEffect, useState } from 'react';
import { getToken } from '../utils/auth';

function CartPage() {
    const [items, setItems] = useState([]);

    useEffect(() => {
        fetch('/api/cart', {
            headers: { Authorization: 'Bearer ' + getToken() },
        })
            .then(res => res.json())
            .then(data => setItems(data));
    }, []);

    const removeFromCart = async (productId) => {
        await fetch('/api/cart/' + productId, {
            method: 'DELETE',
            headers: {
                Authorization: 'Bearer ' + getToken(),
            },
        });
        setItems(items.filter(item => item.productId !== productId)); 
        alert('����� �������� � ������');
    };

    const placeOrder = async () => {
        const res = await fetch('/api/order', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + getToken(),
            },
            body: JSON.stringify({ paymentMethod: 'CreditCard' }),
        });
        if (res.ok) {
            alert('���������� ���������!');
            setItems([]); 
        }
    };

    return (
        <div>
            <h2>�����</h2>
            {items.length === 0 ? (
                <p>��� ����� �������.</p>
            ) : (
                <ul className="list-group">
                    {items.map(item => (
                        <li key={item.id} className="list-group-item d-flex justify-content-between align-items-center">
                            {item.product.name} - {item.product.price} ��� x {item.quantity}
                            <button className="btn btn-danger btn-sm" onClick={() => removeFromCart(item.product.id)}>
                                ��������
                            </button>
                        </li>
                    ))}
                </ul>
            )}
            {items.length > 0 && (
                <button className="btn btn-success mt-3" onClick={placeOrder}>
                    �������� ����������
                </button>
            )}
        </div>
    );
}

export default CartPage;