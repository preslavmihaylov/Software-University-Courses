var Post = (function () {
    function Post(objectId, authorId, content, username, imageUrl, dateCreated) {
        this.id = objectId;
        this.author = username;
        this.imageUrl = imageUrl;
        this.authorId = authorId;
        this.content = content;

        var date = new Date(Date.parse(dateCreated));
        this.dateCreated = ''
            + ('0' + date.getDay()).slice(-2)
            + '.' + ('0' + date.getMonth()).slice(-2)
            + '.' + date.getFullYear();
    }

    return Post;
}());