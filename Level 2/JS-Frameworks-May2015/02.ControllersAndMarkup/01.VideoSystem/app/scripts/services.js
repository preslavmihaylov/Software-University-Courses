app.factory('videoFactory', function() {
    var factory = {};

    var videos = [
    {
        title: 'Course introduction',
        pictureUrl: 'http://softuni.bg/picture.png',
        length: '3:32',
        category: 'IT',
        subscribers: 3,
        date: new Date(2014, 12, 15),
        hasSubtitles: false,
        comments: [
            {
                username: 'Pesho Peshev',
                content: 'Congratulations Nakov',
                date: new Date(2014, 12, 15, 12, 30, 0),
                likes: 3,
                websiteUrl: 'http://pesho.com/'
            }
        ]
    }];

    factory.getVideos = function() {
        return videos;
    }

    factory.addVideo = function(title, picture, length, category, subtitles) {
        videos.push({
            'title': title,
            'pictureUrl': picture,
            'length': length,
            'category': category,
            'subscribers': 0,
            'date': new Date(),
            'hasSubtitles': subtitles,
            'comments': []
        });
    }

    return factory;
})