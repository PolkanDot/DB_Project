import 'dart:core';
import 'package:dio/dio.dart';
import '../models/booking.dart';

String baseUrl = 'https://10.0.2.2:7172/bookings';

Future<List<Booking>?> getRolesOfFilm(int idBooking) async {
  try {
    List<Booking> bookings = [];
    Response response = await Dio().get('$baseUrl/$idBooking');
    print(response.data.toString());
    if (response.data != null) {
      for(var booking in response.data) {
        bookings.add(Booking.fromJson(booking));
      }
    }
    return bookings;
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