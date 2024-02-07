part of '../category_create_form.dart';

mixin _CategoryCreateMixin on State<CategoryCreateForm>{

  TextEditingController collectDescription=TextEditingController();
  TextEditingController collectValue = TextEditingController();
  CategoryCreator? categoryCreator;
  DateTime? startDate;
  DateTime? endDate;

}