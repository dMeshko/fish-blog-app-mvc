angular.module("blog.app.mvc")
    .factory("BlogService", function($http) {
        var factory = {};

        factory.getAllPosts = function() {
            return $http.get("/Blog/GetPostAllPosts");
        }

        factory.getPostById = function(postId) {
            return $http.get("/Blog/GetPostById?id=" + postId);
        }

        factory.deletePost = function (postId) {
            return $http.post("/Blog/DeletePost?id=" + postId);
        }

        factory.createPost = function (data) {
            return $http.post("/Blog/CreatePost", data);
        }

        factory.updatePost = function (data) {
            return $http.post("/Blog/UpdatePost", data);
        }

        factory.createComment = function (post) {
            return $http.post("/Blog/CreateComment", post);
        }

        factory.deleteComment = function (commentId) {
            return $http.post("/Blog/DeleteComment?id=" + commentId);
        }

        return factory;
    });