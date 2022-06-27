using AutoMapper;
using MinimalAPI.Dtos;
using MinimalAPI.Models;

namespace MinimalAPI.profiles;

public class CommandsFile:Profile{
    public CommandsFile(){
        //Source to Target
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<CommandUpdateDto, Command>();
    }
}