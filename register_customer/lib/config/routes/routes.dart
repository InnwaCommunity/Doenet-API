import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:register_customer/modules/customer/bloc/customer_screen_state_manage_bloc.dart';
import 'package:register_customer/modules/customer/repository/customer_repository.dart';
import 'package:register_customer/modules/customer/screens/customer_screen.dart';
import 'package:register_customer/modules/home/bloc/home_screen_state_management_bloc.dart';
import 'package:register_customer/modules/home/screens/home_screen.dart';
import 'package:register_customer/modules/sign%20in/bloc/login_bloc.dart';
import 'package:register_customer/modules/sign%20in/repository/login_repository.dart';
import 'package:register_customer/modules/sign%20in/screens/login_page.dart';
import 'package:register_customer/modules/sign%20up/bloc/signup_state_management_bloc.dart';
import 'package:register_customer/modules/sign%20up/repository/sign_up_repository.dart';
import 'package:register_customer/modules/sign%20up/screens/sign_up_screen.dart';
import 'package:register_customer/modules/splash_screen/bloc/splash_state_management_bloc.dart';
import 'package:register_customer/modules/splash_screen/screens/splash_screen.dart';
import 'package:register_customer/services/function_service.dart';

class Routes {
  static const splashScreen = '/';
  static const login = 'login';
  static const signup = 'signup';
  static const home = 'home';
  static const customerpage = 'customer';

  static Route<dynamic>? routeGenerator(RouteSettings settings) {
    // final argument=settings.arguments;
    switch (settings.name) {
      case '/':
        return makeRoute(
            BlocProvider(
              create: (context) =>
                  SplashStateManagementBloc(LoginRepositoryImpl()),
              child: const SplashScreen(),
            ),
            settings);

      case 'login':
        return makeRoute(
            BlocProvider(
              create: (context) => LoginBloc(LoginRepositoryImpl()),
              child: LoginPage(),
            ),
            settings);

      case 'signup':
        return makeRoute(
            BlocProvider(
              create: (context) => SignupStateManagementBloc(
                  LoginRepositoryImpl(), SignUpRepositoryImpl()),
              child: const SignUpScreen(),
            ),
            settings);

      case 'home':
        return makeRoute(
            BlocProvider(
              create: (context) => HomeScreenStateManagementBloc(),
              child: const HomeScreen(),
            ),
            settings);

      case 'customer':
        return makeRoute(
            BlocProvider(
              create: (context) =>
                  CustomerScreenStateManageBloc(CustomerRepositoryImpl()),
              child: const CustomerPage(),
            ),
            settings);
    }
    return null;
  }
}
