import React, { useState } from 'react';

function RegisterPage() {
    const [form, setForm] = useState({ username: '', email: '', password: '' });

    const handleChange = (e) =>
        setForm({ ...form, [e.target.name]: e.target.value });

    const handleSubmit = async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(form),
        });
        const data = await res.json();
        alert(data.message || 'Успішна реєстрація!');
    };

    return (
        <div className="col-md-6 offset-md-3">
            <h2>Реєстрація</h2>
            <form onSubmit={handleSubmit}>
                <input className="form-control mb-2" name="username" placeholder="Ім'я" onChange={handleChange} />
                <input className="form-control mb-2" name="email" placeholder="Email" onChange={handleChange} />
                <input className="form-control mb-2" name="password" placeholder="Пароль" type="password" onChange={handleChange} />
                <button className="btn btn-primary w-100" type="submit">Зареєструватися</button>
            </form>
        </div>
    );
}

export default RegisterPage;