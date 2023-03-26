import 'dart:core';
import '../models/booking.dart';
import 'package:dio/dio.dart';

String baseUrl = 'https://10.0.2.2:7172/booking';

Future<Booking?> deleteBooking(
    int idBooking) async {
  try {
    Response response = await Dio().delete('$baseUrl/$idBooking');
    print(response.data.toString());
    return Booking.fromJson(response.data);
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