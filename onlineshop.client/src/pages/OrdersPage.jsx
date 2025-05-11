import React, { useEffect, useState } from 'react';
import { getToken } from '../utils/auth';

function OrdersPage() {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        fetch('/api/order/my', {
            headers: {
                Authorization: 'Bearer ' + getToken(),
            },
        })
            .then(res => res.json())
            .then(data => setOrders(data));
    }, []);

    return (
        <div>
            <h2>�� ����������</h2>
            {orders.length === 0 ? (
                <p>�� �� �� ������� ������� ����������.</p>
            ) : (
                <ul className="list-group">
                    {orders.map(order => (
                        <li key={order.id} className="list-group-item">
                            <h5>���������� �{order.id}</h5>
                            <p>������: {order.status}</p>
                            <p>����: {new Date(order.orderDate).toLocaleString()}</p>
                            <p>����: {order.totalAmount} ���</p>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default OrdersPage;