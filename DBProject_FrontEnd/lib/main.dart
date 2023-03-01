import 'dart:io';
import 'package:flutter/material.dart';

import 'routes/welcome.dart';
import 'routes/sign_up.dart';
import 'routes/log_in.dart';

import 'routes/select_city.dart';

import 'routes/cinemas_list.dart';
import 'routes/add_cinema.dart';
import 'routes/edit_cinema.dart';

import 'routes/admin_films_list.dart';
import 'routes/edit_film.dart';
import 'routes/add_film.dart';

import 'routes/add_actor.dart';

import 'routes/admin_roles_list.dart';

import 'routes/halls_list.dart';
import 'routes/add_hall.dart';
import 'routes/edit_hall.dart';

import 'routes/places_list.dart';
import 'routes/add_place.dart';
import 'routes/edit_place.dart';


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
        '/list_cinemas': (context) => CinemaList(),
        '/add_cinema': (context) => AddCinema(),
        '/edit_cinema': (context) => EditCinema(),
        '/admin_list_films': (context) => AdminFilmList(),
        '/edit_film': (context) => EditFilm(),
        '/list_halls': (context) => HallsList(),
        '/add_hall': (context) => AddHall(),
        '/edit_hall': (context) => EditHall(),
        '/list_places': (context) => PlacesList(),
        '/add_place': (context) => AddPlace(),
        '/edit_place': (context) => EditPlace(),
        '/add_film': (context) => AddFilm(),
        '/add_actor': (context) => AddActor(),
        '/admin_list_roles': (context) => AdminRoleList(),
      },
    ),
  );
}