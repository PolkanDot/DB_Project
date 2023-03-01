import 'package:flutter/material.dart';
import '../callApi/create_actor.dart';
import '../models/actor.dart';

class AddActor extends StatelessWidget {
  AddActor({Key? key}) : super(key: key);
  final _formKey = GlobalKey<FormState>();
  Actor? actor = Actor(
      idActor: 0,
      name: "",
      idImage: null,
      roles: []);
  bool duplicate = false;

  @override
  Widget build(BuildContext context) {

    return WillPopScope(
        child: Scaffold(
            appBar: AppBar(
              title: const Text("Add actor"),
              centerTitle: true,
            ),
            body: Form(
                key: _formKey,
                autovalidateMode: AutovalidateMode.always,
                child: ListView(
                    padding: const EdgeInsets.symmetric(horizontal: 24),
                    children: [
                      // добавить к каждому сравнение с исходным значением в поле, чтобы не вызывать апи в случае если данные не изменились
                      // добавить проверку на валидность ввода (найти в инете как проверять имена людей и тп)
                      TextFormField(
                        onChanged: (String value) => {actor!.name = value},
                        decoration: const InputDecoration(labelText: "Actor name"),
                        initialValue: actor!.name,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Enter actor name';
                          }
                          return null;
                        },
                      ),
                      ElevatedButton(
                        onPressed: () {
                          createActor(actor!.name);
                          Navigator.pushReplacementNamed(context, '/admin_list_films');
                        },
                        child: const Text("SAVE"),
                      ),
                    ]))),
        onWillPop: () async {
          Navigator.pushReplacementNamed(context, '/admin_list_films');
          return Future.value(true);
        }
    );
  }
}