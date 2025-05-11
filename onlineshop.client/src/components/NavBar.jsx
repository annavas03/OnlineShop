import React from 'react';
import { Link } from 'react-router-dom';

function NavBar() {
    return (
        <nav className="navbar navbar-expand navbar-dark bg-dark">
            <div className="container">
                <Link className="navbar-brand" to="/">�������</Link>
                <div className="navbar-nav">
                    <Link className="nav-link" to="/">������</Link>
                    <Link className="nav-link" to="/cart">�����</Link>
                    <Link className="nav-link" to="/orders">�� ����������</Link>
                    <Link className="nav-link" to="/profile">̳� �������</Link>
                </div>
                <div className="navbar-nav ms-auto">
                    <Link className="nav-link" to="/login">����</Link>
                    <Link className="nav-link" to="/register">���������</Link>
                </div>
            </div>
        </nav>
    );
}

export default NavBar;