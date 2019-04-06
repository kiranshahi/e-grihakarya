"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var login_component_1 = require("./login/login.component");
var register_component_1 = require("./register/register.component");
var auth_guard_1 = require("./_guards/auth.guard");
var role_1 = require("./_models/role");
var course_details_component_1 = require("./course-details/course-details.component");
var appRoutes = [
    {
        path: '',
        component: home_component_1.HomeComponent,
        canActivate: [auth_guard_1.AuthGuard]
    },
    {
        path: 'login',
        component: login_component_1.LoginComponent
    },
    {
        path: 'register',
        component: register_component_1.RegisterComponent,
        canActivate: [auth_guard_1.AuthGuard],
        data: { roles: [role_1.Role.Admin] }
    },
    {
        path: 'course/:id',
        component: course_details_component_1.CourseDetailsComponent,
        canActivate: [auth_guard_1.AuthGuard],
        data: { roles: [role_1.Role.Admin] }
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map