angular.module("blog.app.mvc")
    .controller("CreatePostDetailsController", function ($scope, BlogService, $state) {
        $scope.create = function() {
            BlogService.createPost($scope.model).then(
                function (response) {
                    $state.go("app.details", { id: response.data });
                }, function (response) {
                    alert(response.data);
                }
            );
        }
    });