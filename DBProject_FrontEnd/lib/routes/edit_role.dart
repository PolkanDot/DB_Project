import 'package:flutter/material.dart';
import '../callApi/delete_role_func.dart';
import '../callApi/edit_role_func.dart';
import '../models/film_and_role_data.dart';

class EditRole extends StatelessWidget {
  EditRole({Key? key}) : super(key: key);

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    FilmAndRole filmAndRole = ModalRoute.of(context)?.settings.arguments as FilmAndRole;
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
                  onChanged: (String value) => {filmAndRole.role.namePersonage = value},
                  decoration: const InputDecoration(labelText: "Cinema name"),
                  initialValue: filmAndRole.role.namePersonage,
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
                      onPressed: () {
                        deleteRole(filmAndRole.role.idRole);
                        Navigator.pushReplacementNamed(context, '/admin_list_roles',
                            arguments: filmAndRole.film);
                      },
                      child: const Text("DELETE"),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        // спросить пользователя сохранять ли изменения, если да вызываем функцию:
                        editRole(filmAndRole.role);
                        Navigator.pushReplacementNamed(context, '/admin_list_roles',
                            arguments: filmAndRole.film);
                      },
                      child: const Text("SAVE"),
                    )
                  ],
                )
              ],
            )),
      ),
      onWillPop: () async {
        Navigator.pushReplacementNamed(context, '/admin_list_roles',
            arguments: filmAndRole.film);
        return Future.value(true);
      },
    );
  }
}