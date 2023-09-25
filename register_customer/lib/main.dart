import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:register_customer/customer_page.dart';
import 'package:register_customer/helper/api_service.dart';
import 'package:register_customer/login_page.dart';
import 'dart:io';

import 'Bloc/login_bloc.dart';

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}

void main() {
  HttpOverrides.global =  MyHttpOverrides();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => LoginBloc(apiService: ApiService()),
      child: MaterialApp(
        title: 'My App',
        initialRoute: '/login',
        routes: {
          '/login': (_) => LoginPage(),
          '/customerpage': (context) => const CustomerPage(),
        },
      ),
    );
  }
}


// class MyApp extends StatelessWidget {
//   const MyApp({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       debugShowCheckedModeBanner: false,
//       title: 'Flutter Demo',
//       theme: ThemeData(
//         primarySwatch: Colors.blue,
//       ),
//       routes: {
//         '/': (context) => LoginPage(),
//         '/customerpage': (context) => const CustomerPage(),
//         // '/searchcustomer': (context) => const SearchCustomer(),
//       },
//       // initialRoute: '/',
//       home: BlocProvider(
//           create: (_) => LoginBloc(apiService: ApiService()),
//           child: LoginPage()),
//     );
//   }
// }
