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
          Navigator.pushNamed(context, "/edit_film", arguments: film),
      title: Text(film.name,
          style: const TextStyle(fontSize: 22, color: Colors.black)),
      subtitle: Text("Age restriction: ${film.ageRating}",
          style: const TextStyle(fontSize: 16, color: Colors.orange)),
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
    return WillPopScope(
        child: Scaffold(
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
            floatingActionButton: Row(
                mainAxisAlignment: MainAxisAlignment.end,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  FloatingActionButton(
                    child: Icon(
                        Icons.video_call
                    ),
                    onPressed: () => Navigator.pushReplacementNamed(context, '/add_film'),
                    heroTag: null,
                  ),
                  SizedBox(
                    height: 10,
                    width: 20,
                  ),
                  FloatingActionButton(
                    child: Icon(
                        Icons.person_add
                    ),
                    onPressed: () => Navigator.pushReplacementNamed(context, '/add_actor'),
                    heroTag: null,
                  )
                ]
            )
        ),
        onWillPop: () async {
          Navigator.pushReplacementNamed(context, '/log_in');
          return Future.value(true);
    }
    );
  }
}
