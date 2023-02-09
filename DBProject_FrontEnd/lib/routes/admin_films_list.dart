import 'package:flutter/material.dart';
import 'package:db_roject_frontend/callApi/getFilms.dart';
import '../models/film.dart';

class FilmCard extends StatelessWidget {
  const FilmCard({required this.film, Key? key}) : super(key: key);

  final Film film;

  @override
  Widget build(BuildContext context) {
    return ListTile(
      onTap: () =>
          /*Navigator.pushNamed(context, "/edit_cinema", arguments: cinema)*/
          print("work"),
      title: Text(film.name,
          style: const TextStyle(fontSize: 22, color: Colors.black)),
      /*subtitle: Text("Address: ${film.address}",
          style: const TextStyle(fontSize: 16, color: Colors.orange)),*/
    );
  }
}

class AdminFilmList extends StatefulWidget {
  AdminFilmList({Key? key}) : super(key: key);

  @override
  State<AdminFilmList> createState() => _AdminFilmListState();
}

class _AdminFilmListState extends State<AdminFilmList> {
  List<Film> _films = [];

  void getAllFilms() async {
    List<Film>? response = await getFilms();
    if (response != null) {
      setState(() {
        _films = response;
      });
    }
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  void didChangeDependencies() {
    getAllFilms();
    super.didChangeDependencies();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("-Films admin page-"),
        centerTitle: true,
      ),
      body: ListView.separated(
          separatorBuilder: (BuildContext context, int index) => const Divider(
            color: Colors.black,
            height: 10,
            thickness: 2,
          ),
          itemCount: _films.length,
          padding: const EdgeInsets.all(20),
          itemBuilder: (BuildContext context, int index) {
            return FilmCard(film: _films[index]);
          }),
      floatingActionButton: OutlinedButton(
        onPressed: () => print("work"), //Navigator.pushNamed(context, "/add_cinema"),
        child: const Icon(
          Icons.add,
          size: Checkbox.width * 3,
          color: Colors.green,
        ),
      ),
    );
  }
}
