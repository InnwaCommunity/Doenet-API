
import 'package:flutter_bloc/flutter_bloc.dart';

part 'home_screen_state_management_event.dart';
part 'home_screen_state_management_state.dart';

class HomeScreenStateManagementBloc extends Bloc<HomeScreenStateManagementEvent, HomeScreenStateManagementState> {
  HomeScreenStateManagementBloc() : super(HomeScreenStateManagementInitial()) {
    on<HomeScreenStateManagementEvent>((event, emit) {});
  }
}
