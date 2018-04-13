angular.module("blog.app.mvc")
    .controller("HomeController", function ($scope, BlogService) {
        BlogService.getAllPosts()
            .then(function (response) {
                $scope.posts = response.data;
            }, function (response) {
                alert(response.data);
            });
    });