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
            <h2>Мої замовлення</h2>
            {orders.length === 0 ? (
                <p>Ви ще не зробили жодного замовлення.</p>
            ) : (
                <ul className="list-group">
                    {orders.map(order => (
                        <li key={order.id} className="list-group-item">
                            <h5>Замовлення №{order.id}</h5>
                            <p>Статус: {order.status}</p>
                            <p>Дата: {new Date(order.orderDate).toLocaleString()}</p>
                            <p>Сума: {order.totalAmount} грн</p>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default OrdersPage;