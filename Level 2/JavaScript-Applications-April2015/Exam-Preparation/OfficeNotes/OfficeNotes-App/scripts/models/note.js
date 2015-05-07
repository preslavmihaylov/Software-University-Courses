var Note = (function () {
    function Note(objectId, title, content, deadline, author) {
        this.id = objectId;
        this.title = title;
        this.content = content;
        this.deadline = deadline;
        this.author = author;
    }

    return Note;
}());