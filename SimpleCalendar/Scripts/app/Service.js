/// <reference path="../angular.js" />
/// <reference path="Module.js" />
app.service("calendarService", function ($http) {
    //Get All Appointments
    this.getAppointments = function () {
        return $http.get("/api/AppointmentsAPI");
    }
    //Get All Appointments for specific month
    this.getMonthAppointments = function (month) {
        return $http.get("/api/AppointmentsAPI?month=" + month);
    }
});