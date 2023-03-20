import 'dart:core';
import '../models/session.dart';
import 'package:dio/dio.dart';

String baseUrl = 'https://10.0.2.2:7172/session';

Future<Session?> createSession(int idFilm, int idHall, DateTime dateTime) async
{
  try {
    Response response = await Dio().post(baseUrl, data: {
      "idHall": idHall,
      "idFilm": idFilm,
      "dateTime": dateTime,
    });
    print(response.data.toString());
    return Session.fromJson(response.data);
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