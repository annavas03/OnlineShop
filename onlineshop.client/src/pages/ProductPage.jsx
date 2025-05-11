import React, { useEffect, useState } from 'react';
import { getToken } from '../utils/auth';

function ProductPage() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch('/api/product')
      .then(res => res.json())
      .then(data => setProducts(data));
  }, []);

  const addToCart = async (productId) => {
    await fetch('/api/cart', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + getToken(),
      },
      body: JSON.stringify({ productId, quantity: 1 }),
    });
    alert('������ �� ������');
  };

  return (
    <div>
      <h2>������</h2>
      <div className="row">
        {products.map(p => (
          <div key={p.id} className="col-md-4 mb-3">
            <div className="card">
              <div className="card-body">
                <h5>{p.name}</h5>
                <p>{p.price} ���</p>
                <button className="btn btn-sm btn-success" onClick={() => addToCart(p.id)}>������</button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default ProductPage;