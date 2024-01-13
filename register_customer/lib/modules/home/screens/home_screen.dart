import 'dart:developer';

import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

import 'package:easy_localization/easy_localization.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:register_customer/config/routes/content_ext.dart';
import 'package:register_customer/config/routes/routes.dart';
import 'package:register_customer/config/themes/app_theme.dart';
import 'package:register_customer/constants/font_size.dart';
import 'package:register_customer/model/clustermodel.dart';
import 'package:register_customer/modules/home/bloc/home_screen_state_management_bloc.dart';
import 'package:register_customer/modules/home/repository/home_screen_repository.dart';
part 'mixin/home_screen_mixin.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> with _HomeScreenMixin {
  @override
  Widget build(BuildContext context) {
    return BlocBuilder<HomeScreenStateManagementBloc,
        HomeScreenStateManagementState>(
      builder: (context, state) {
        return BlocListener<HomeScreenStateManagementBloc,
            HomeScreenStateManagementState>(
          listener: (context, state) {
            if (state is LoadClusterSuccess) {
              clusterList = state.clusterList;
            }
            if (state is LoadClusterError) {
              context.back(Routes.login);
            }
            if (state is CreateClusterSuccess) {
              loadClusterList();
            }
            if (state is CreateClusterFail) {
              if (state.error != 'backtoLogin') {
                showDialog(
                    context: context,
                    builder: (context) {
                      return AlertDialog(
                        content: Text(state.error),
                        actions: [
                          TextButton(
                              onPressed: () => Navigator.of(context).pop(),
                              child: const Text('Ok'))
                        ],
                      );
                    });
              } else {
                context.back(Routes.login);
              }
            }
          },
          child: Scaffold(
            backgroundColor: Colors.white,
            appBar: AppBar(
              title: Text('Happy Cooky',
                  style: TextStyle(
                      fontSize: context.locale == const Locale('my', 'MM')
                          ? navigationBarTextFontSizeMM
                          : navigationBarTextFontSize)),
              automaticallyImplyLeading: false,
              actions: [
                IconButton(
                    onPressed: () {
                      context.left(Routes.login, (route) => false);
                    },
                    icon: const Icon(Icons.exit_to_app_sharp))
              ],
            ),
            body: clusterList.isNotEmpty
                ? _bodyWidget()
                : const Center(
                    child: CircularProgressIndicator(),
                  ),
            floatingActionButton: FloatingActionButton(
              onPressed: () {
                // context.toName(Routes.addMenuItem);
                createCluster();
              },
              child: const Text('New'),
            ),
          ),
        );
      },
    );
  }

  void createCluster() {
    TextEditingController clusterTextEdit = TextEditingController();
    TextEditingController passTextEdit = TextEditingController();
    bool isUsePas = false;
    showDialog(
        barrierDismissible: false,
        context: context,
        builder: (context) {
          return PopScope(
            canPop: false,
            child: BlocProvider(
              create: (context) =>
                  HomeScreenStateManagementBloc(HomeScreenRepositoryImpl()),
              child: BlocBuilder<HomeScreenStateManagementBloc,
                  HomeScreenStateManagementState>(
                builder: (context, state) {
                  return AlertDialog(
                    title: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text(
                          'Create Cluster',
                          textAlign: TextAlign.center,
                          style: TextStyle(),
                        ),
                        Switch(
                          value: isUsePas,
                          onChanged: (value) {
                            isUsePas = value;
                            BlocProvider.of<HomeScreenStateManagementBloc>(
                                    context)
                                .add(HomeScreenStateChangeEvent());
                          },
                          activeColor: Colors.blue,
                          activeTrackColor: Colors.grey,
                          inactiveThumbColor: Colors.grey,
                          inactiveTrackColor: Colors.blueGrey,
                        )
                      ],
                    ),
                    content: SizedBox(
                      height: isUsePas ? 100 : 50,
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          TextFormField(
                            controller: clusterTextEdit,
                            decoration: const InputDecoration(
                                hintText: 'Cluster Name',
                                icon: Icon(Icons.edit)),
                          ),
                          Visibility(
                            visible: isUsePas,
                            child: TextFormField(
                              controller: passTextEdit,
                              decoration: const InputDecoration(
                                  hintText: 'Password', icon: Icon(Icons.edit)),
                            ),
                          ),
                        ],
                      ),
                    ),
                    actions: [
                      TextButton(
                          onPressed: () {
                            Navigator.of(context).pop();
                          },
                          child: const Text('Cancel')),
                      TextButton(
                          onPressed: () {
                            Navigator.of(context).pop('ok');
                          },
                          child: const Text('Ok')),
                    ],
                  );
                },
              ),
            ),
          );
        }).then((value) {
      if (value == 'ok') {
        if (isUsePas) {
          TextEditingController conTextEdit = TextEditingController();
          GlobalKey<FormFieldState> confirmKey = GlobalKey<FormFieldState>();
          showDialog(
              barrierDismissible: false,
              context: context,
              builder: (context) {
                return AlertDialog(
                  content: SizedBox(
                    height: 75,
                    child: Column(
                      children: [
                        TextFormField(
                          controller: conTextEdit,
                          decoration: const InputDecoration(
                              hintText: 'Confirm Password',
                              icon: Icon(Icons.edit)),
                          validator: (value) {
                            if (value != null && passTextEdit.text != conTextEdit.text) {
                              return tr('Password is not match');
                            }
                            return null;
                          },
                          key: confirmKey,
                          onChanged: (val) => confirmKey.currentState!.validate(),
                        ),
                      ],
                    ),
                  ),
                  actions: [
                    TextButton(
                        onPressed: () => Navigator.of(context).pop(),
                        child: const Text('Cancel')),
                    TextButton(
                        onPressed: () {
                          if (confirmKey.currentState!.validate()) {
                            Navigator.of(context).pop('Confirm');
                          }
                        },
                        child: const Text('Confirm'))
                  ],
                );
              }).then((value) {
            if (value == 'Confirm') {
              BlocProvider.of<HomeScreenStateManagementBloc>(context).add(
                  CreateClusterEvent(
                      clusterName: clusterTextEdit.text,
                      isPassUse: isUsePas,
                      pass: passTextEdit.text));
            }
          });
        } else {
          BlocProvider.of<HomeScreenStateManagementBloc>(context).add(
              CreateClusterEvent(
                  clusterName: clusterTextEdit.text,
                  isPassUse: isUsePas,
                  pass: passTextEdit.text));
        }
      }
    });
  }

  Widget _bodyWidget() {
    return ListView.separated(
        // shrinkWrap: true,
        itemBuilder: (context, index) {
          return ExpansionTile(
            // controller: expancontroller,
            collapsedBackgroundColor: AppTheme.grey.withOpacity(.2),
            iconColor: AppTheme.deactivatedText,
            textColor: AppTheme.deactivatedText,
            collapsedTextColor: AppTheme.deactivatedText,
            collapsedIconColor: AppTheme.deactivatedText,
            initiallyExpanded: false,
            onExpansionChanged: (value) {
              // log('onExpansionChanged $value');
              // if (value && !clusterList[index].isVertify!) {
              //   showDialog(
              //       context: context,
              //       builder: (context) {
              //         return AlertDialog(
              //           title: const Text('Need to vertify password'),
              //           actions: [
              //             TextButton(
              //                 onPressed: () {
              //                   Navigator.of(context).pop();
              //                 },
              //                 child: const Text('Confirm'))
              //           ],
              //         );
              //       });
              // }
            },
            title: Text(tr('Cluster')),
            trailing: GestureDetector(
              child: const Text(
                'Details',
                style: TextStyle(color: Colors.redAccent),
              ),
              onTap: () {
                showDialog(
                    context: context,
                    builder: (context) {
                      return const AlertDialog(
                        title: Text('Sorry,Now Developing'),
                      );
                    });
              },
            ),
            subtitle: Text(
                '${clusterList[index].numberOfMember!.toString()} Members'),
            children: [
              clusterList[index].isVertify!
                  ? _clusterListDetail(index)
                  : _verifyPassword(index),
            ],
          );
        },
        separatorBuilder: (context, index) => const Divider(
              thickness: 0,
            ),
        itemCount: clusterList.length);
  }

  Widget _verifyPassword(int index){
    TextEditingController validatePassword=TextEditingController();
    GlobalKey<FormFieldState> validatePas = GlobalKey<FormFieldState>();
    return Padding(
      padding: const EdgeInsets.fromLTRB(15, 0, 0, 0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          const Text('This Cluster Type need to verify password',textAlign: TextAlign.start,),
          Row(
            children: [
              Expanded(
                child: TextFormField(
                  controller: validatePassword,
                  key: validatePas,
                  decoration: const InputDecoration(
                    hintText: 'Entrer Password',
                  ),
                  validator: (value){
                    if (value == null && value!.isEmpty) {
                      return 'Please fill Something';
                    }
                    return null;
                  },
                ),
              ),
              ElevatedButton(
                  onPressed: () {
                    if (validatePas.currentState!.validate()) {
                      BlocProvider.of<HomeScreenStateManagementBloc>(context)
                          .add(ClusterPasswordValidate(
                              password: validatePassword.text,
                              clusterIdval: clusterList[index].clusterIdval!));
                    }
                  },
                  child: const Text('Verify'))
            ],
          ),
        ],
      ),
    );
  }

  Widget _clusterListDetail(int index) {
    return Container(
      margin: const EdgeInsets.all(5),
      // height: MediaQuery.of(context).size.height / 1.5,
      child: Column(
        children: [
          AspectRatio(
            aspectRatio: 1.70,
            child: Padding(
              padding: const EdgeInsets.only(
                right: 10,
                left: 0,
                top: 10,
                bottom: 10,
              ),
              child: LineChart(
                index == 1 ? avgData() : mainData(),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(5, 0, 5, 0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                MaterialButton(
                  minWidth: 40,
                  height: 70,
                  shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(50),
                      side: const BorderSide(color: Colors.black)),
                  onPressed: () {
                    context.toName(Routes.totalhistory);
                  },
                  child: const Column(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Text('Total'),
                      // Text(
                      //     '   ${SharedPref.getTotalBalance().toInt()}   ')
                    ],
                  ),
                ),
                MaterialButton(
                  minWidth: 40,
                  height: 70,
                  shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(50),
                      side: const BorderSide(color: Colors.black)),
                  onPressed: () {},
                  child: const Column(
                    children: [Text('Total'), Text('123456789')],
                  ),
                ),
                MaterialButton(
                  minWidth: 40,
                  height: 70,
                  shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(50),
                      side: const BorderSide(color: Colors.black)),
                  onPressed: () {},
                  child: const Column(
                    children: [Text('Total'), Text('123456789')],
                  ),
                ),
                MaterialButton(
                    minWidth: 30,
                    height: 45,
                    color: Colors.blue,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50),
                        side: const BorderSide(color: Colors.red)),
                    onPressed: () {
                      addItem();
                    },
                    child: const Icon(Icons.add)),
              ],
            ),
          ),
          const Divider(
            thickness: 1,
            height: 30,
          ),
          const Padding(
            padding: EdgeInsets.fromLTRB(10, 0, 10, 0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text('ItemName'),
                Text('Prices'),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(10, 10, 10, 0),
            child: SizedBox(
              height: 100,
              child: ListView.separated(
                  // shrinkWrap: true,
                  itemBuilder: (context, index) {
                    return const Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [Text('Computer'), Text('2000123')],
                    );
                  },
                  separatorBuilder: (context, index) => const Divider(
                        thickness: 1,
                      ),
                  itemCount: 3),
            ),
          )
        ],
      ),
    );
  }

  void addItem() {
    showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            title: const Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text('List of Items'),
                Icon(Icons.add),
              ],
            ),
            // icon: const Icon(Icons.add),
            content: SizedBox(
              height: 300, // Set an appropriate height for the list
              child: SingleChildScrollView(
                child: Column(
                  children: List.generate(10, (index) {
                    return Column(
                      children: [
                        TextFormField(
                          controller: itemNameController,
                          keyboardType: TextInputType.text,
                          enabled: true,
                          textInputAction: TextInputAction.next,
                          decoration: const InputDecoration(
                            // prefixIcon:
                            //      Icon(Icons.search),
                            // enabledBorder:
                            //     OutlineInputBorder(
                            //   borderRadius:
                            //        BorderRadius.all(
                            //     Radius.circular(30),
                            //   ),
                            //   borderSide: BorderSide(
                            //     color: AppTheme.grey,
                            //   ),
                            // ),
                            hintText: 'Search',
                            isDense: true,
                            contentPadding: EdgeInsets.all(10),
                            border: OutlineInputBorder(
                              borderRadius: BorderRadius.all(
                                Radius.circular(30),
                              ),
                              borderSide: BorderSide(
                                color: AppTheme.grey,
                              ),
                            ),
                          ),
                          onChanged: (value) {},
                        ),
                        const Divider(),
                      ],
                    );
                  }),
                ),
              ),
            ),
            actions: [
              TextButton(
                onPressed: () {
                  // Add your action here.
                },
                child: const Text('Cancel'),
              ),
              TextButton(
                onPressed: () {
                  // Add your action here.
                },
                child: const Text('OK'),
              ),
            ],
          );
        });
  }

  Widget bottomTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
      fontWeight: FontWeight.bold,
      fontSize: 16,
    );
    Widget text;
    switch (value.toInt()) {
      case 2:
        text = const Text('MAR', style: style);
        break;
      case 5:
        text = const Text('JUN', style: style);
        break;
      case 8:
        text = const Text('SEP', style: style);
        break;
      default:
        text = const Text('', style: style);
        break;
    }

    return SideTitleWidget(
      axisSide: meta.axisSide,
      child: text,
    );
  }

  Widget leftTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
      fontWeight: FontWeight.bold,
      fontSize: 15,
    );
    String text;
    switch (value.toInt()) {
      case 1:
        text = '10K';
        break;
      case 3:
        text = '30k';
        break;
      case 5:
        text = '50k';
        break;
      default:
        return Container();
    }

    return Text(text, style: style, textAlign: TextAlign.left);
  }

  LineChartData mainData() {
    return LineChartData(
      gridData: FlGridData(
        show: true,
        drawVerticalLine: true,
        horizontalInterval: 1,
        verticalInterval: 1,
        getDrawingHorizontalLine: (value) {
          return const FlLine(
            color: AppColors.mainGridLineColor,
            strokeWidth: 1,
          );
        },
        getDrawingVerticalLine: (value) {
          return const FlLine(
            color: AppColors.mainGridLineColor,
            strokeWidth: 1,
          );
        },
      ),
      titlesData: const FlTitlesData(
        show: true,
        rightTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        topTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            reservedSize: 30,
            interval: 2,
            // getTitlesWidget: bottomTitleWidgets,
          ),
        ),
        // leftTitles: AxisTitles(
        //   sideTitles: SideTitles(
        //     showTitles: true,
        //     interval: 1,
        //     getTitlesWidget: leftTitleWidgets,
        //     reservedSize: 42,
        //   ),
        // ),
      ),
      borderData: FlBorderData(
        show: true,
        border: Border.all(color: const Color(0xff37434d)),
      ),
      minX: 1,
      maxX: 31,
      minY: 0,
      maxY: 6,
      lineBarsData: [
        LineChartBarData(
          spots: const [
            FlSpot(1, 3),
            FlSpot(2, 2),
            FlSpot(3, 5),
            FlSpot(4, 3.1),
            FlSpot(5, 4),
            FlSpot(6, 3),
            FlSpot(7, 4),
            FlSpot(8, 4),
            FlSpot(9.5, 3),
            FlSpot(10, 3),
            FlSpot(11, 3),
            FlSpot(12.6, 2),
            FlSpot(13.9, 5),
            FlSpot(14.8, 3.1),
            FlSpot(15, 4),
            FlSpot(16, 3),
            FlSpot(17, 4),
            FlSpot(18, 4),
            FlSpot(19.5, 3),
            FlSpot(20, 3),
            FlSpot(21, 3),
            FlSpot(22.6, 2),
            FlSpot(23.9, 5),
            FlSpot(24.8, 3.1),
            FlSpot(25, 4),
            FlSpot(26, 3),
            FlSpot(27, 4),
            FlSpot(28, 4),
            FlSpot(29.5, 3),
            FlSpot(30, 3),
            FlSpot(31, 3),
          ],
          isCurved: true,
          gradient: LinearGradient(
            colors: gradientColors,
          ),
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: const FlDotData(
            show: false,
          ),
          belowBarData: BarAreaData(
            show: true,
            gradient: LinearGradient(
              colors: gradientColors
                  .map((color) => color.withOpacity(0.3))
                  .toList(),
            ),
          ),
        ),
      ],
    );
  }

  LineChartData avgData() {
    return LineChartData(
      lineTouchData: const LineTouchData(enabled: false),
      gridData: FlGridData(
        show: true,
        drawHorizontalLine: true,
        verticalInterval: 1,
        horizontalInterval: 1,
        getDrawingVerticalLine: (value) {
          return const FlLine(
            color: Color(0xff37434d),
            strokeWidth: 1,
          );
        },
        getDrawingHorizontalLine: (value) {
          return const FlLine(
            color: Color(0xff37434d),
            strokeWidth: 1,
          );
        },
      ),
      titlesData: const FlTitlesData(
        show: true,
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            reservedSize: 30,
            // getTitlesWidget: bottomTitleWidgets,
            interval: 2,
          ),
        ),
        // leftTitles: AxisTitles(
        //   sideTitles: SideTitles(
        //     showTitles: true,
        //     getTitlesWidget: leftTitleWidgets,
        //     reservedSize: 42,
        //     interval: 1,
        //   ),
        // ),
        topTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        rightTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
      ),
      borderData: FlBorderData(
        show: true,
        border: Border.all(color: const Color(0xff37434d)),
      ),
      minX: 1,
      maxX: 31,
      minY: 0,
      maxY: 6,
      lineBarsData: [
        LineChartBarData(
          spots: const [
            FlSpot(1, 3),
            FlSpot(2, 2),
            FlSpot(3, 5),
            FlSpot(4, 3.1),
            FlSpot(5, 4),
            FlSpot(6, 3),
            FlSpot(7, 4),
            FlSpot(8, 4),
            FlSpot(9.5, 3),
            FlSpot(10, 3),
            FlSpot(11, 3),
            FlSpot(12.6, 2),
            FlSpot(13.9, 5),
            FlSpot(14.8, 3.1),
            FlSpot(15, 4),
            FlSpot(16, 3),
            FlSpot(17, 4),
            FlSpot(18, 4),
            FlSpot(19.5, 3),
            FlSpot(20, 3),
            FlSpot(21, 3),
            FlSpot(22.6, 2),
            FlSpot(23.9, 5),
            FlSpot(24.8, 3.1),
            FlSpot(25, 4),
            FlSpot(26, 3),
            FlSpot(27, 4),
            FlSpot(28, 4),
            FlSpot(29.5, 3),
            FlSpot(30, 3),
            FlSpot(31, 3),
          ],
          isCurved: true,
          gradient: LinearGradient(
            colors: [
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
            ],
          ),
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: const FlDotData(
            show: false,
          ),
          belowBarData: BarAreaData(
            show: true,
            gradient: LinearGradient(
              colors: [
                ColorTween(begin: gradientColors[0], end: gradientColors[1])
                    .lerp(0.2)!
                    .withOpacity(0.1),
                ColorTween(begin: gradientColors[0], end: gradientColors[1])
                    .lerp(0.2)!
                    .withOpacity(0.1),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
