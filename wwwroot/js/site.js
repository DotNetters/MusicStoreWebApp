// Write your Javascript code.
angular
    .module('app', [])
        .controller('musicStoreCtrl', ['$http', '$rootScope', '$timeout', function($http, $rootScope, $timeout){
            var vm = this;
            vm.shoppingCart = [];
            
            $http.get('/api/musictracks').then(function(response){
                vm.tracks = response.data;
            });
            
            vm.IsInCart = function(trackId) {
                return vm.shoppingCart.indexOf(trackId) >= 0;
            }
            
            vm.AddToCart = function(trackId) {
                vm.shoppingCart.push(trackId);
            }
            
            vm.RemoveFromCart = function(trackId) {
                vm.shoppingCart.splice(vm.shoppingCart.indexOf(trackId));                
            }
            
        }]);