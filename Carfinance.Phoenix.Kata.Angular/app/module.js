(function () {
    'use strict';

    angular.module('PhoenixKata', ['ngRoute'])

        .controller('bookingController', function ($scope, $http) {
            //declare variable for mainain ajax load and entry or edit mode
            $scope.loading = true;
            $scope.addMode = false;
            $scope.viewMode = true;

            //get all booking information
            $http.get('booking').then(function (response) {
                $scope.bookings = response.data;
                $scope.loading = false
            })
            
            //by pressing toggleEdit button ng-click in html, this method will be hit
            $scope.toggleEdit = function () {
                this.booking.editMode = !this.booking.editMode;
            };

            //by pressing toggleAdd button ng-click in html, this method will be hit
            $scope.toggleAdd = function () {
                $scope.addMode = !$scope.addMode;
                $scope.viewMode = !$scope.viewMode;
            };

            $scope.add = function () {
                $scope.loading = true;
                var mydata = JSON.stringify(this.newbooking);
                $http({
                    url: 'booking',
                    method: "POST",
                    data: this.newbooking,
                    headers: { 'Content-Type': 'application/json;charset=utf-8' },
                }).then(function (response) {
                    console.log('Successful Insert')  
                    $http.get('booking').then(function (response) {
                        $scope.bookings = response.data;
                    });
                    $scope.addMode = false;
                    $scope.viewMode = true;
                }); 
            };

            //Edit Booking
            $scope.save = function () {
                var editedBooking = this.booking;
                $http({
                    url: 'booking',
                    method: "PUT",
                    data: this.booking,
                    headers: { 'Content-Type': 'application/json;charset=utf-8' },
                }).then(function (response) {
                    console.log("Booking updated successfully");
                    editedBooking.editMode = false;
                });           
            };

           

            
        });
})();
