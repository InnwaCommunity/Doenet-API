import 'dart:async';
import 'dart:developer';
import 'package:flutter/foundation.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:register_customer/model/login_data_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ApiService {
  String accessToken = '';

  Future<LoginDataModel> postAuthData(
      String apiUrl,
      Map<String, String> requestHeaders,
      Map<String, dynamic> requestBody) async {
    try {
      Uri url = Uri.parse(apiUrl);
      log(url.toString());
      Map<String, String> requestHeaders = {'Content-type': 'application/json'};

      var response = await http.post(url,
          body: jsonEncode(requestBody), headers: requestHeaders);
          log(response.statusCode.toString());
      if (response.statusCode == 200) {
        LoginDataModel loginDataModel =
            LoginDataModel.fromJson(jsonDecode(response.body));
        accessToken = loginDataModel.accessToken ?? '';
        log('token is $accessToken');
        final prefs = await SharedPreferences.getInstance();
        prefs.setString('accessToken', accessToken);
        return loginDataModel;
      } else if (response.statusCode == 400) {
        return LoginDataModel.fromJson(jsonDecode(response.body));
      }
    } catch (e) {
      if (kDebugMode) {
        print(e.toString());
      }
    }
    return LoginDataModel(
      accessToken: null,
      expiresIn: null,
      userId: null,
      loginType: null,
      userLevelId: null,
      displayName: null,
    );
  }
}

class SignInException implements Exception {
  final String message;
  SignInException(this.message);
  @override
  String toString() => 'SignInException: $message';
}
