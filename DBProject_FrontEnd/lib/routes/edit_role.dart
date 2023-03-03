import 'package:flutter/material.dart';
import '../callApi/delete_role_func.dart';
import '../models/role.dart';
import '../callApi/edit_role_func.dart';

class EditCinema extends StatelessWidget {
  EditCinema({Key? key}) : super(key: key);

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    Role role = ModalRoute.of(context)?.settings.arguments as Role;
    return WillPopScope(
      child: Scaffold(
        appBar: AppBar(
          title: const Text("Edit role data"),
        ),
        body: Form(
            key: _formKey,
            autovalidateMode: AutovalidateMode.always,
            child: ListView(
              padding: const EdgeInsets.symmetric(horizontal: 24),
              children: [
                // добавить к каждому сравнение с исходным значением в поле, чтобы не вызывать апи в случае если данные не изменились
                TextFormField(
                  onChanged: (String value) => {role.namePersonage = value},
                  decoration: const InputDecoration(labelText: "Cinema name"),
                  initialValue: role.namePersonage,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Enter role name';
                    }
                    return null;
                  },
                ),
                OverflowBar(
                  alignment: MainAxisAlignment.end,
                  children: [
                    ElevatedButton(
                      onPressed: () {/*
                        deleteRole(role.idRole);
                        Navigator.pushReplacementNamed(context, '/list_cinemas',
                            arguments: routesData);*/
                      },
                      child: const Text("DELETE"),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        // спросить пользователя сохранять ли изменения, если да вызываем функцию:
                        /*editRole(role);
                        Navigator.pushReplacementNamed(context, '/list_halls',
                            arguments: routesData);*/
                      },
                      child: const Text("SAVE"),
                    )
                  ],
                )
              ],
            )),
      ),
      onWillPop: () async {
        Navigator.pushReplacementNamed(context, '/list_cinemas',
            arguments: routesData);
        return Future.value(true);
      },
    );
  }
}