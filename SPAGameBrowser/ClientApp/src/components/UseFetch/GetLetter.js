﻿import authService from '../api-authorization/AuthorizeService';

export const getLetter = async () => {
    try {
        const token = await authService.getAccessToken();

        const response = await fetch(`api/Letters`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();
        return result;
    } catch (error) {
        console.error('Error: ', error);
        throw error;
    }
};