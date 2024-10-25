const express = require('express');
const path = require('path');
const app = express();

// Serve static files like CSS, JS, and images
app.use(express.static(path.join(__dirname, 'public')));

// Sample data for travel articles (with provided Imgur image URLs)
const articles = [
    {
        id: 1,
        name: 'Mt Cook',
        author: 'John Doe',
        text: 'Mt Cook is the highest mountain in New Zealand, known for its stunning snow-capped peaks.',
        images: [
            { url: 'https://i.imgur.com/ul6n9QI.jpeg' }
        ]
    },
    {
        id: 2,
        name: 'Wanaka',
        author: 'Jane Smith',
        text: 'Wanaka is a resort town famous for its lakes and stunning mountain views.',
        images: [
            { url: 'https://i.imgur.com/i8hCvXJ.jpeg' }
        ]
    },
    {
        id: 3,
        name: 'The Church of the Good Shepherd',
        author: 'Samuel Green',
        text: 'Located on the shores of Lake Tekapo, the Church of the Good Shepherd offers spectacular views.',
        images: [
            { url: 'https://i.imgur.com/6SyvM9k.jpeg' }
        ]
    },
    {
        id: 4,
        name: 'The Roy’s Peak',
        author: 'John Doe',
        text: 'Roy’s Peak offers breathtaking panoramic views of Lake Wanaka and surrounding peaks.',
        images: [
            { url: 'https://i.imgur.com/yrWS7H1.jpeg' }
        ]
    },
    {
        id: 5,
        name: 'Hobbiton Movie Set',
        author: 'Jane Smith',
        text: 'Explore the iconic Hobbiton movie set from the Lord of the Rings and The Hobbit trilogies.',
        images: [
            { url: 'https://i.imgur.com/qi1v9y6.jpeg' }
        ]
    },
    {
        id: 6,
        name: 'Queenstown',
        author: 'Samuel Green',
        text: 'Queenstown is the adventure capital of New Zealand, offering everything from skiing to bungee jumping.',
        images: [
            { url: 'https://i.imgur.com/MOYcFhh.jpeg' }
        ]
    }
];

// API route to get articles
app.get('/api/articles', (req, res) => {
    res.json(articles); // Respond with the articles array in JSON format
});

// Catch-all route to serve index.html (for your frontend)
app.get('*', (req, res) => {
    res.sendFile(path.join(__dirname, 'public', 'index.html'));
});

// Start the server on port 3000
const port = process.env.PORT || 3000;
app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});
