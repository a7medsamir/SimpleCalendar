/// <reference path="../angular.js" />
/// <reference path="Module.js" />
app.controller("calendarController", function ($scope, calendarService) {
    $scope.Appointments = [];
    $scope.SelectedAppointment;
    $scope.Months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                          "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    $scope.showMonthAppointments = function (month) {
        var promiseMonthAppointments = calendarService.getMonthAppointments(month);

        promiseMonthAppointments.then(
            function(result) {
                var appointments = result.data;
                $scope.Appointments = appointments;
            },
            function(errorPl) {
                console.log('failure loading month appointments', errorPl);
            });
    }
    $scope.showAppointmentDetails = function (appointment) {
        $scope.SelectedAppointment = appointment;
    }
});