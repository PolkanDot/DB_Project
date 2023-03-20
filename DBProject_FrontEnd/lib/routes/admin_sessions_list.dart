import 'package:flutter/material.dart';
import 'package:db_roject_frontend/callApi/get_sessions_of_cinema.dart';
import '../models/session_info.dart';
import '../models/cinema.dart';

class SessionCard extends StatelessWidget {
  SessionCard({required this.sessionInfo, Key? key}) : super(key: key);

  final SessionInfo sessionInfo;
  String hallType = "";

  @override
  Widget build(BuildContext context) {
    switch (sessionInfo.hallType) {
      case(0):
        hallType = "2D";
        break;
      case(1):
        hallType = "3D";
        break;
      case(2):
        hallType = "iMax 2D";
        break;
      case(3):
        hallType = "iMax 3D";
        break;
      default:
        hallType = "?";
        break;
    }
    return ListTile(
      onTap: () {},
          //Navigator.pushNamed(context, "/edit_film", arguments: film),
      title: Text(sessionInfo.filmName,
          style: const TextStyle(fontSize: 22, color: Colors.black)),
      subtitle: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          Text("Зал: ${sessionInfo.hallNumber}",
              style: const TextStyle(fontSize: 16, color: Colors.orange)),
          Text("Тип зала: ${sessionInfo.hallType}",
              style: const TextStyle(fontSize: 16, color: Colors.orange)),
          Text("Дата: ${sessionInfo.dateTime.day}.${sessionInfo.dateTime.month}",
              style: const TextStyle(fontSize: 16, color: Colors.orange)),
          Text("Время: ${sessionInfo.dateTime.hour}:${sessionInfo.dateTime.minute}",
              style: const TextStyle(fontSize: 16, color: Colors.orange)),
        ],
      )
    );
  }
}

class AdminSessionList extends StatefulWidget {
  AdminSessionList({Key? key}) : super(key: key);

  @override
  State<AdminSessionList> createState() => _AdminSessionListState();
}

class _AdminSessionListState extends State<AdminSessionList> {
  List<SessionInfo> _sessions = [];

  void getAllSessions() async {
    Cinema cinema = ModalRoute.of(context)?.settings.arguments as Cinema;
    List<SessionInfo>? response = await getSessionsOfCinema(cinema.idCinema);
    if (response != null) {
      setState(() {
        _sessions = response;
      });
    }
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  void didChangeDependencies() {
    getAllSessions();
    super.didChangeDependencies();
  }

  @override
  Widget build(BuildContext context) {
    Cinema cinema = ModalRoute.of(context)?.settings.arguments as Cinema;
    return WillPopScope(
        child: Scaffold(
            appBar: AppBar(
              title: Text("-Администраторский список фильмов кинотеатра ${cinema.name}-"),
              centerTitle: true,
            ),
            body: ListView.separated(
                separatorBuilder: (BuildContext context, int index) => const Divider(
                  color: Colors.black,
                  height: 10,
                  thickness: 2,
                ),
                itemCount: _sessions.length,
                padding: const EdgeInsets.all(20),
                itemBuilder: (BuildContext context, int index) {
                  return SessionCard(sessionInfo: _sessions[index]);
                }),
            floatingActionButton: Row(
                mainAxisAlignment: MainAxisAlignment.end,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  FloatingActionButton(
                    child: Icon(
                        Icons.video_call
                    ),
                    onPressed: () {},//=> Navigator.pushReplacementNamed(context, '/add_film'),
                    heroTag: null,
                  ),
                  SizedBox(
                    height: 10,
                    width: 20,
                  ),
                  FloatingActionButton(
                    child: Icon(
                        Icons.people
                    ),
                    onPressed: () {},//=> Navigator.pushReplacementNamed(context, '/admin_list_actors'),
                    heroTag: null,
                  )
                ]
            )
        ),
        onWillPop: () async {
          Navigator.pushReplacementNamed(context, "/log_in",);
          return Future.value(true);
        }
    );
  }
}
