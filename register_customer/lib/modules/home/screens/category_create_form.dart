import 'package:easy_localization/easy_localization.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:register_customer/config/Sharef/share_pref.dart';
import 'package:register_customer/config/themes/app_theme.dart';
import 'package:register_customer/constants/assets.dart';
import 'package:register_customer/constants/constants.dart';
import 'package:register_customer/model/category_creator.dart';
import 'package:register_customer/modules/home/bloc/category_create_form_state_management_bloc.dart';
part 'mixin/category_create_mixin.dart';

class CategoryCreateForm extends StatefulWidget {
  const CategoryCreateForm({super.key});

  @override
  State<CategoryCreateForm> createState() => _CategoryCreateFormState();
}

class _CategoryCreateFormState extends State<CategoryCreateForm>
    with _CategoryCreateMixin {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        title: const Text('Category Create Form'),
        actions: [
          IconButton(onPressed: (){}, icon:const Icon(Icons.send))
        ],
      ),
      body: BlocProvider(
        create: (context) => CategoryCreateFormStateManagementBloc(),
        child: Padding(
          padding: const EdgeInsets.only(left: 20,right: 20),
          child: Column(
            children: [
              Row(
                children: [
                  InkWell(
                    onTap: () {},
                    child: Container(
                      height: 55, //55
                      width: 55, //55
                      padding: const EdgeInsets.all(2),
                      clipBehavior: Clip.hardEdge,
                      decoration: const BoxDecoration(
                        shape: BoxShape.circle,
                        color: Colors.grey,
                      ),
                      child: Container(
                        decoration: BoxDecoration(
                          color: Colors.blue,
                          border: Border.all(
                            color: Colors.white,
                            width: 2.5,
                          ),
                          shape: BoxShape.circle,
                        ),
                        child: ClipOval(
                          child: SizedBox.fromSize(
                            size: const Size.fromRadius(48),
                            child: categoryCreator == null ||
                                    categoryCreator!.creatorName == ''
                                ? Image(
                                    image: AssetImage(Assets().gear5),
                                    height: 55,
                                    width: 55,
                                  )
                                : Text(categoryCreator!.creatorName!
                                    .substring(0, 1),textAlign: TextAlign.center,style: const TextStyle(fontSize: 30),),
                          ),
                        ),
                      ),
                    ),
                  ),
                  const SizedBox(width: 10,),
                  Visibility(
                    visible: categoryCreator==null ||  categoryCreator!.creatorName=='',
                    child: TextButton(
                        onPressed: () async {
                          List<String>? loginInf =
                              await SharedPref.getStringList(key: shploginInfo);
                          String? username = loginInf?.first;
                          categoryCreator = CategoryCreator(
                              creatoridval: '', creatorName: username ?? '');
                              setState(() {});
                        },
                        child: const Text('Create MySelf',style: TextStyle(fontSize: 15),)),
                  ),
                  categoryCreator != null && categoryCreator!.creatorName!.isNotEmpty ? Text(categoryCreator!.creatorName!,style: const TextStyle(fontSize: 15),):Container()
                  // Visibility(
                  //     visible: categoryCreator != null &&
                  //         categoryCreator!.creatorName!.isNotEmpty,
                  //     child: Text(categoryCreator!.creatorName!))
                ],
              ),
              TextFormField(
                keyboardType: TextInputType.number,
                controller: collectDescription,
                decoration: InputDecoration(
                                  enabledBorder: const UnderlineInputBorder(
                                      borderSide: BorderSide(
                                          color: Colors.grey)),
                                  labelText: tr('Collect Value'),
                                  labelStyle: TextStyle(
                                      fontSize: context.locale ==
                                              const Locale('my', 'MM')
                                          ? 13
                                          : 16,
                                      color: Theme.of(context)
                                          .colorScheme
                                          .secondaryContainer),
                                  hintText: tr('Enter Your Collect Value'),
                                  hintStyle: TextStyle(
                                    fontSize: context.locale ==
                                            const Locale('my', 'MM')
                                        ? 15
                                        : 16,
                                  )),
              ),
              TextFormField(
                controller: collectValue,
                decoration: InputDecoration(
                                  enabledBorder: const UnderlineInputBorder(
                                      borderSide: BorderSide(
                                          color: Colors.grey)),
                                  labelText: tr('Description'),
                                  labelStyle: TextStyle(
                                      fontSize: context.locale ==
                                              const Locale('my', 'MM')
                                          ? 13
                                          : 16,
                                      color: Theme.of(context)
                                          .colorScheme
                                          .secondaryContainer),
                                  hintText: tr('Enter Your Description'),
                                  hintStyle: TextStyle(
                                    fontSize: context.locale ==
                                            const Locale('my', 'MM')
                                        ? 15
                                        : 16,
                                  )),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  ElevatedButton(
                      onPressed: () async{
                        showDatePicker(
                          context: context,
                          initialDate: startDate ?? endDate ?? DateTime.now(),
                          firstDate: DateTime(1900),
                          lastDate: endDate ?? DateTime(2100),
                          helpText: 'SELECT DATE',
                          cancelText: 'CANCEL',
                          builder: (context, child) {
                             return AppTheme.datePickerComponent(child: child!, context: context);
                          },
                        ).then((value){
                          if (value != null) {
                            startDate=value;
                             setState(() {});
                          }
                        });
                      },
                      child: Text(startDate == null
                          ? 'Select Start Date'
                          : '${startDate!.year} / ${startDate!.month} / ${startDate!.day}')),
                  ElevatedButton(
                      onPressed: () {
                        showDatePicker(
                          context: context,
                          initialDate: endDate ?? startDate ?? DateTime.now(),
                          firstDate: startDate ?? DateTime(1900),
                          lastDate:  DateTime(2100),
                          helpText: 'SELECT DATE',
                          cancelText: 'CANCEL',
                          builder: (context, child) {
                             return AppTheme.datePickerComponent(child: child!, context: context);
                          },
                        ).then((value) {
                          if (value != null) {
                            endDate=value;
                            setState(() {});
                          }
                        });
                      },
                      child: Text(endDate == null
                          ? 'Select End Date'
                          : '${endDate!.year} / ${endDate!.month} / ${endDate!.day}')),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
