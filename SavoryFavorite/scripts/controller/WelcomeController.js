function WelcomeController($scope, $state, $stateParams, SavoryFavoriteService) {

    function favorite_items_callback(response) {

        $scope.items_loaded = true;

        if (response.status !== 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    {
        SavoryFavoriteService.favorite_items({}).then(favorite_items_callback);
    }

}
