
import 'package:shared_preferences/shared_preferences.dart';

class SharedPref {
  static Future<String?> getString({required String key}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.getString(key);
  }
  static Future<bool> setString({required String key,required String value}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.setString(key, value);
  }
  static Future<List<String>?> getStringList({required String key}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.getStringList(key);
  }
  static Future<bool> setStringList({required String key,required List<String> value}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.setStringList(key, value);
  }
  static Future<bool?> getBool({required String key}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.getBool(key);
  }
  static Future<bool> setBool({required String key,required bool value}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.setBool(key, value);
  }
  static Future<int?> getInt({required String key}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.getInt(key);
  }
  static Future<bool> setInt({required String key,required int value}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.setInt(key, value);
  }
  static Future<double?> getDouble({required String key}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.getDouble(key);
  }
  static Future<bool> setDouble({required String key,required double value}) async{
    SharedPreferences shp= await SharedPreferences.getInstance();
    return shp.setDouble(key, value);
  }
}