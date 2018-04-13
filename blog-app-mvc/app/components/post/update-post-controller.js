angular.module("blog.app.mvc")
    .controller("UpdatePostDetailsController", function ($scope, BlogService, $state, $stateParams) {
        var postId = $stateParams.id;

        BlogService.getPostById(postId).then(function(response) {
            $scope.post = response.data;
            $scope.model = response.data;
        }, function(response) {
            alert(response.data);
            });

        $scope.update = function() {
            BlogService.updatePost($scope.model).then(
                function (response) {
                    $state.go("app.details", {id: $scope.model.Id});
                }, function (response) {
                    alert(response.data);
                }
            );
        }

        $scope.resetModel = function() {
            $scope.model = angular.copy($scope.post);
        }
    });