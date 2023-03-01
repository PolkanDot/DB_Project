import 'package:flutter/material.dart';
import '../models/film.dart';

class AddFilm extends StatelessWidget {
  AddFilm({Key? key}) : super(key: key);
  final _formKey = GlobalKey<FormState>();
  Film? film = Film(
    idFilm: 0,
    name: "",
    duration: "",
    ageRating: 0,
    description: "",
    idImage: null,
    roles: [],
    sessions: []);
  bool duplicate = false;

  @override
  Widget build(BuildContext context) {

    return WillPopScope(
        child: Scaffold(
            appBar: AppBar(
              title: const Text("Create film"),
              centerTitle: true,
            ),
            body: Form(
                key: _formKey,
                autovalidateMode: AutovalidateMode.always,
                child: ListView(
                    padding: const EdgeInsets.symmetric(horizontal: 24),
                    children: [
                      // добавить к каждому сравнение с исходным значением в поле, чтобы не вызывать апи в случае если данные не изменились
                      TextFormField(
                        onChanged: (String value) => {film!.name = value},
                        decoration: const InputDecoration(labelText: "Film name"),
                        initialValue: film!.name,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Enter film name';
                          }
                          return null;
                        },
                      ),
                      TextFormField(
                        onChanged: (String value) => {film!.duration = value},
                        decoration: const InputDecoration(labelText: "Film duration"),
                        initialValue: film!.duration,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Enter film duration';
                          }
                          return null;
                        },
                      ),
                      TextFormField(
                        keyboardType: TextInputType.number,
                        // Добавить проверку на валидность введенного числа для возраста, (-1 0321)
                        onChanged: (String value) {
                          if (int.tryParse(value) != null)
                          {
                            film!.ageRating = int.parse(value);
                          }
                          else
                          {
                            film!.ageRating = -1;
                          }
                        },
                        decoration: const InputDecoration(labelText: "Film age restriction"),
                        initialValue: film!.ageRating.toString(),
                        validator: (value) {
                          if (value == null || value.isEmpty || film!.ageRating == -1) {
                            return 'Enter valid age';
                          }
                          return null;
                        },
                      ),
                      TextFormField(
                        maxLines: 5,
                        minLines: 1,
                        keyboardType: TextInputType.text,
                        // Добавить проверку на валидность введенного числа для возраста, (-1 0321)
                        onChanged: (String value) {
                          film!.description = value;
                        },
                        decoration: const InputDecoration(labelText: "Film descrioption"),
                        initialValue: film!.description,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Enter film description';
                          }
                          return null;
                        },
                      ),
                      ElevatedButton(
                        onPressed: () async {

                          /*routesData.hall = (await createHall(hall!.idCinema,
                          hall!.number, hall!.type, hall!.capacity))!;
                      Navigator.pushReplacementNamed(context, '/list_places',
                          arguments: routesData);*/
                        },
                        child: const Text("ADD ROLES->"),
                      ),
                    ]))),
        onWillPop: () async {
          Navigator.pushReplacementNamed(context, '/admin_list_films');
          return Future.value(true);
        }
    );
  }
}