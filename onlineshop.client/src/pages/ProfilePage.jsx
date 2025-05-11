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
                    throw new Error('�� ������� �������� �������');
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
            <h2>̳� �������</h2>
            {profile ? (
                <div>
                    <p><strong>��'�:</strong> {profile.username}</p>
                    <p><strong>Email:</strong> {profile.email}</p>
                </div>
            ) : (
                <p>������������...</p>
            )}
        </div>
    );
};

export default ProfilePage;
