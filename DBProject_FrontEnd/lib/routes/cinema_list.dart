import 'package:flutter/material.dart';
import 'package:db_roject_frontend/callApi/get_cinemas_of_city.dart';

import '../models/cinema.dart';

class CinemaList extends StatefulWidget {
  CinemaList({required this.cityName, required this.accountRole,Key? key}) : super(key: key);

  final String cityName;
  final int accountRole;

  @override
  State<CinemaList> createState() => _CinemaListState();
}

class _CinemaListState extends State<CinemaList> {
  List<Cinema> _cinemas = [];

  void getCinemas() async {
    List<Cinema>? response = await getCinemasOfCity(widget.cityName);
    if (response != null) {
      setState(() {
        _cinemas = response;
      });
    }
  }

  @override
  void initState() {
    getCinemas();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    if (widget.accountRole == 0)
      {
        return Scaffold(
          appBar: AppBar(
            title: const Text("-Step 2-"),
            centerTitle: true,
          ),
          body: ListView.builder(
              itemCount: _cinemas.length,
              itemBuilder: (BuildContext context, int index) {
                return Column(children: [
                  OutlinedButton(
                    onPressed: () {},
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(_cinemas[index].name,
                            style:
                            const TextStyle(fontSize: 22, color: Colors.black)),
                        Text("Address: ${_cinemas[index].address}",
                            style: const TextStyle(
                                fontSize: 16, color: Colors.orange)),
                      ],
                    ),
                  ),
                  const SizedBox(
                    height: 30,
                  ),
                ]);
              }),
        );
      }
    else
    {
      return Scaffold(
        appBar: AppBar(
          title: const Text("-Admin page-"),
          centerTitle: true,
        ),
        body: ListView.builder(
            itemCount: _cinemas.length,
            itemBuilder: (BuildContext context, int index) {
              return Column(children: [
                OutlinedButton(
                  onPressed: () {},
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(_cinemas[index].name,
                          style:
                          const TextStyle(fontSize: 22, color: Colors.black)),
                      Text("Address: ${_cinemas[index].address}",
                          style: const TextStyle(
                              fontSize: 16, color: Colors.orange)),
                    ],
                  ),
                ),
                const SizedBox(
                  height: 30,
                ),
              ]);
            }),
      );
    }
  }
}