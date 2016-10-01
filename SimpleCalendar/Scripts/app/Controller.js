/// <reference path="../angular.js" />
/// <reference path="Module.js" />
app.controller("calendarController", function ($scope, calendarService) {
    $scope.Appointments = [];
    $scope.SelectedAppointment = null;
    $scope.SelectedMonth = 0;
    $scope.Months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                          "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    // Show all appointments of selected month
    $scope.showMonthAppointments = function (month) {
        $scope.SelectedMonth = month;
        $scope.SelectedAppointment = null;
        var promiseMonthAppointments = calendarService.getMonthAppointments(month);
        promiseMonthAppointments.then(
            function (result) {
                var appointments = result.data;
                $scope.Appointments = appointments;
            },
            function (errorPl) {
                console.log('failure loading month appointments', errorPl);
            });
    }

    // Show Details of selected appointment
    $scope.showAppointmentDetails = function (appointment) {
        $scope.SelectedAppointment = appointment;
    }

    // Load by default screen to Feb month
    $scope.showMonthAppointments(2);
});