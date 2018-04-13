angular.module("blog.app.mvc")
    .controller("PostDetailsController", function ($scope, BlogService, $state, $stateParams) {
        var postId = $stateParams.id;

        BlogService.getPostById(postId).then(function (response) {
            $scope.post = response.data;
        }, function (response) {
            alert(response.data);
        });

        $scope.deletePost = function () {
            BlogService.deletePost($scope.post.Id).then(
                function (response) {
                    $state.go("app");
                }, function (response) {
                    alert(response.data);
                }
            );
        }

        $scope.comment = {
            PostId: postId
        };
        $scope.postComment = function () {
            BlogService.createComment($scope.comment).then(
                function (response) {
                    // reset
                    $scope.comment = {
                        PostId: postId
                    };
                    $scope.showCommentBox = !$scope.showCommentBox;

                    // refresh model
                    BlogService.getPostById(postId).then(function (response) {
                        $scope.post = response.data;
                    }, function (response) {
                        alert(response.data);
                    });
                }, function (response) {
                    alert(response.data);
                }
            );
        }

        $scope.deleteComment = function (commentId) {
            BlogService.deleteComment(commentId).then(
                function (response) {
                    BlogService.getPostById(postId).then(function (response) {
                        $scope.post = response.data;
                    }, function (response) {
                        alert(response.data);
                    });
                }, function (response) {
                    alert(response.data);
                }
            );
        }
    });