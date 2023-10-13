import authService from './api-authorization/AuthorizeService';

export const boardDefault = [
    ["", "", "", "", ""],
    ["", "", "", "", ""],
    ["", "", "", "", ""],
    ["", "", "", "", ""],
    ["", "", "", "", ""],
    ["", "", "", "", ""],
];

export const getWord = async () => {
    let selectedWord;

    try {
        const token = await authService.getAccessToken();
        const response = await fetch(`api/Words`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();
        const wordArr = Array.from(result).map(item => item.wordName.split('\n'));
        const flattenedArray = [].concat(...wordArr);
        const selectedWord = flattenedArray[Math.floor(Math.random() * flattenedArray.length)];
        const wordSet = new Set(flattenedArray);
        return { wordSet, selectedWord };
    } catch (error) {
        console.error('Error: ', error);
        throw error; 
    }
};