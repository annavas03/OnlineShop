import { useState, useEffect } from 'react';

import { getToken } from './utils/auth'; 

const ProfilePage = () => {
    const [profile, setProfile] = useState(null);

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const response = await fetch('/api/profile', {
                    headers: {
                        Authorization: 'Bearer ' + getToken(),
                    },
                });

                if (!response.ok) {
                    throw new Error('Не вдалося отримати профіль');
                }

                const data = await response.json();
                setProfile(data);
            } catch (error) {
                console.error('Error fetching profile:', error);
            }
        };

        fetchProfile();
    }, []);

    return (
        <div>
            <h2>Мій профіль</h2>
            {profile ? (
                <div>
                    <p><strong>Ім'я:</strong> {profile.username}</p>
                    <p><strong>Email:</strong> {profile.email}</p>
                </div>
            ) : (
                <p>Завантаження...</p>
            )}
        </div>
    );
};

export default ProfilePage;
