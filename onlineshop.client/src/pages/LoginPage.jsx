import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { setToken } from '../utils/auth';

function LoginPage() {
    const [form, setForm] = useState({ email: '', password: '' });
    const navigate = useNavigate();

    const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

    const handleSubmit = async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(form),
        });
        const data = await res.json();
        if (data.token) {
            setToken(data.token);
            navigate('/');
        } else {
            alert('Помилка входу');
        }
    };

    return (
        <div className="col-md-6 offset-md-3">
            <h2>Вхід</h2>
            <form onSubmit={handleSubmit}>
                <input className="form-control mb-2" name="email" placeholder="Email" onChange={handleChange} />
                <input className="form-control mb-2" name="password" type="password" placeholder="Пароль" onChange={handleChange} />
                <button className="btn btn-primary w-100">Увійти</button>
            </form>
        </div>
    );
}

export default LoginPage;