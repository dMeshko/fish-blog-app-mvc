angular.module("blog.app.mvc")
    .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("app",
            {
                url: "/",
                views: {
                    "content": {
                        controller: "HomeController",
                        templateUrl: "app/components/home/home.html"
                    }
                }
            })
            .state("app.details",
                {
                    url: "/details/:id",
                    views: {
                        "content@": {
                            controller: "PostDetailsController",
                            templateUrl: "app/components/post/post.html"
                        }
                    }
            })
            .state("app.update",
                {
                    url: "/update/:id",
                    views: {
                        "content@": {
                            controller: "UpdatePostDetailsController",
                            templateUrl: "app/components/post/update-post.html"
                        }
                    }
            })
            .state("app.create",
                {
                    url: "/create",
                    views: {
                        "content@": {
                            controller: "CreatePostDetailsController",
                            templateUrl: "app/components/post/create-post.html"
                        }
                    }
                });
    }]);