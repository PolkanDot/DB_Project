import 'package:flutter/material.dart';
import 'package:db_roject_frontend/callApi/get_roles_of_film.dart';
import 'package:db_roject_frontend/callApi/get_actor_by_idActor.dart';
import '../models/role.dart';
import '../models/actor.dart';
import '../models/film.dart';

class RoleCard extends StatefulWidget {
  RoleCard({required this.role, Key? key}) : super(key: key);

  final Role role;

  @override
  State<RoleCard> createState() => _RoleCardState();
}

class _RoleCardState extends State<RoleCard> {
  Actor? actor;

  void getActor() async {
    Actor? response = await getActorByIdActor(widget.role.idActor);
    if (response != null) {
      setState(() {
        actor = response;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    getActor();
    return ListTile(
      onTap: () {print(actor!.name);},
          //Navigator.pushNamed(context, "/edit_film", arguments: film),
      title: Text(widget.role.namePersonage,
          style: const TextStyle(fontSize: 22, color: Colors.black)),
      subtitle: Text("Actor: ${actor!.name}",
          style: const TextStyle(fontSize: 16, color: Colors.orange)),
    );
  }
}

class AdminRoleList extends StatefulWidget {
  AdminRoleList({Key? key}) : super(key: key);

  @override
  State<AdminRoleList> createState() => _AdminRoleListState();
}

class _AdminRoleListState extends State<AdminRoleList> {
  List<Role> _roles = [];

  void getAllRoles() async {
    Film film = ModalRoute.of(context)?.settings.arguments as Film;
    List<Role>? response = await getRolesOfFilm(film.idFilm);
    if (response != null) {
      setState(() {
        _roles = response;
      });
    }
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  void didChangeDependencies() {
    getAllRoles();
    super.didChangeDependencies();
  }

  @override
  Widget build(BuildContext context) {
    Film film = ModalRoute.of(context)?.settings.arguments as Film;
    return WillPopScope(
        child: Scaffold(
            appBar: AppBar(
              title: Text("List Roles in Film:\n${film.name}"),
              centerTitle: true,
            ),
            body: ListView.separated(
                separatorBuilder: (BuildContext context, int index) => const Divider(
                  color: Colors.black,
                  height: 10,
                  thickness: 2,
                ),
                itemCount: _roles.length,
                padding: const EdgeInsets.all(20),
                itemBuilder: (BuildContext context, int index) {
                  return RoleCard(role: _roles[index]);
                }),
          floatingActionButton: OutlinedButton(
            onPressed: () {}, //Navigator.pushNamed(context, "/add_cinema", arguments: routesData),
            child: const Icon(
              Icons.add,
              size: Checkbox.width * 3,
              color: Colors.green,
            ),
          ),
        ),
        onWillPop: () async {
          Navigator.pushReplacementNamed(context, "/edit_film", arguments: film);
          return Future.value(true);
        }
    );
  }
}