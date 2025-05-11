import React from 'react';
import { Link } from 'react-router-dom';

function NavBar() {
    return (
        <nav className="navbar navbar-expand navbar-dark bg-dark">
            <div className="container">
                <Link className="navbar-brand" to="/">Магазин</Link>
                <div className="navbar-nav">
                    <Link className="nav-link" to="/">Товари</Link>
                    <Link className="nav-link" to="/cart">Кошик</Link>
                    <Link className="nav-link" to="/orders">Мої замовлення</Link>
                    <Link className="nav-link" to="/profile">Мій профіль</Link>
                </div>
                <div className="navbar-nav ms-auto">
                    <Link className="nav-link" to="/login">Вхід</Link>
                    <Link className="nav-link" to="/register">Реєстрація</Link>
                </div>
            </div>
        </nav>
    );
}

export default NavBar;