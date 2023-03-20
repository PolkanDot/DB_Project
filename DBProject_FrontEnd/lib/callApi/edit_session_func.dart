import 'dart:core';
import 'package:dio/dio.dart';
import '../models/session.dart';

String baseUrl = 'https://10.0.2.2:7172/editSession';

Future<Session?> editSession(Session? session) async {
  try {
    if (session != null) {
      Response response = await Dio().put(baseUrl, data: {
        'idSession': session.idSession,
        'idFilm': session.idFilm,
        'idHall': session.idHall,
        'dateTime': session.dateTime,
      });
      print(response.data.toString());
      return Session.fromJson(response.data);
    }
    return null;
  } on DioError catch (e) {
    if (e.response != null) {
      print(e.response!.data);
    } else {
      print(e.requestOptions);
      print(e.message);
    }
    return null;
  }
}