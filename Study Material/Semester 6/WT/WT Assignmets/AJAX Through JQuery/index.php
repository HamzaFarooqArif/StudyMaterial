<!DOCTYPE html>
<html >
<style>
    table, th , td  {
        border: 1px solid grey;
        border-collapse: collapse;
        padding: 5px;
    }
    table tr:nth-child(odd) {
        background-color: #f1f1f1;
    }
    table tr:nth-child(even) {
        background-color: #ffffff;
    }
</style>
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
<body>

<div ng-app="myApp" ng-controller="customersCtrl">

    <table>
        <tr ng-repeat="x in tablename">
            <td>{{ x.id }}</td>
            <td>{{ x.username }}</td>
        </tr>
    </table>

</div>

<script>
    var app = angular.module('myApp', []);
    app.controller('customersCtrl', function($scope, $http) {
        $http.get("data.php")
            .then(function (response) {$scope.names = response.data.records;});
    });
</script>

</body>
</html>




<!--<!doctype html>
<html ng-app="app">
<head lang="en">
    <title>Assignment</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
</head>
<body ng-controller="ajaxCtrl">
<div class="Container">
    <div class="row">
        <table class="table">
            <thead>
            <th>ID</th>
            <th>Username</th>
            <th>Password</th>
            </thead>
            <tbody>
            <tr ng-repeat = "res in results"></tr>
            <td>{{res.id}}</td>
            <td>{{res.username}}</td>
            <td>{{res.password}}</td>
            </tbody>
            <tfooter>
                <th>ID</th>
                <th>Username</th>
                <th>Password</th>
            </tfooter>
        </table>
    </div>
</div>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
<script type="text/javascript">
    angular.module('app', []).
        controller('ajaxCtrl', function($scope, $http){
            $http({
                method: 'POST',
                url: '/data.php'
            }).success(function (data) {
                $scope.results = data;
            });
    });
</script>
</body>
</html>-->