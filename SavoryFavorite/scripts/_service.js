function SavoryFavoriteService($resource, $q) {

    var resource = $resource('api', {}, {

        favorite_items: { method: 'POST', url: 'api/favorite/items' }
    });

    return {

        favorite_items: function (request) { var d = $q.defer(); resource.favorite_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; }
    };
}
