import 'dart:io';
import 'package:flutter/material.dart';
import 'package:db_roject_frontend/routes/cinema_list.dart';
import 'package:db_roject_frontend/routes/welcome.dart';
import 'package:db_roject_frontend/routes/actions_with_cinema.dart';
import 'routes/select_city.dart';
import 'routes/sign_up.dart';
import 'routes/log_in.dart';
import 'routes/keyboard_test.dart';

class MyHttpOverrides extends HttpOverrides{
  @override
  HttpClient createHttpClient(SecurityContext? context){
    return super.createHttpClient(context)
      ..badCertificateCallback = ((X509Certificate cert, String host, int port) {
        final isValidHost = ["10.0.2.2"].contains(host); // <-- allow only hosts in array
        return isValidHost;
      });
  }
}

void main() {
  HttpOverrides.global = MyHttpOverrides();
  runApp(
    MaterialApp(
      theme: ThemeData(
          colorSchemeSeed: const Color(0xffff8af9), useMaterial3: true),
      debugShowCheckedModeBanner: false,
      initialRoute: '/',
      routes: {
        '/': (context) => const Welcome(),
        '/log_in': (context) => Authorization(),
        '/register': (context) => SignUp(),
        '/cities': (context) => SelectCity(),
        '/cinema_actions': (context) => ActionWithCinema(),
        '/keyboard': (context) => MyHomePage(title: 'Virtual Keyboard Demo'),
      },
    ),
  );
}