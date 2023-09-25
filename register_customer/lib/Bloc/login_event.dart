abstract class LoginEvent {}

class PerformLoginEvent extends LoginEvent {
  final String username;
  final String password;

  PerformLoginEvent({required this.username, required this.password});
}


// abstract class LoginEvent {}

// class PerformLoginEvent extends LoginEvent {
//   final String username;
//   final String password;

//   PerformLoginEvent({required this.username, required this.password});
// }
