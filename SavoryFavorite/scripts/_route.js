var route = function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when('', '/welcome').when('/', '/welcome');

    $stateProvider.state('app', {
        url: '/',
        views: {
            'header': { templateUrl: 'scripts/view/view_header.html?v=' + window.releaseNo },
            'main-menu': { templateUrl: 'scripts/view/view_menu.html?v=' + window.releaseNo},
            'main-body': { template: '<div ui-view></div>' }
        }
    });

    $stateProvider.state('app.welcome', { url: 'welcome', templateUrl: 'scripts/view/view_welcome.html?v=' + window.releaseNo, controller: WelcomeController });
 
    $stateProvider.state('app.otherwise', {
        url: '*path',
        templateUrl: 'views/view_404.html?v=' + window.releaseNo
    });
}